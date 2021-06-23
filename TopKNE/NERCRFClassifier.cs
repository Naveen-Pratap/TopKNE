using edu.stanford.nlp.ie.crf;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    public class NERCRFClassifier : INER
    {
        private readonly string _root;
        protected CRFClassifier Classifier = null;
        protected bool disposed;

        public NERCRFClassifier()
        {
            _root = @"C:\Users\navee\source\repos\TopKNE\stanford-ner-2020-11-17\classifiers";
            Classifier = CRFClassifier.getClassifierNoExceptions(_root + @"\english.all.3class.distsim.crf.ser.gz");
        }

        // ~ methods are called by the garbage collector at end of execution of files
        // this makes sure a fresh model is used for evaluating Named Entities
        // https://stackoverflow.com/questions/4742687/putting-a-tilde-in-front-of-a-method-call
        ~NERCRFClassifier()
        {
            this.Dispose(false);
        }

        protected List<string> ParseResult(string txt)
        {
            List<string> res = new List<string>();
            string[] tmp = txt.Split(' ');
            if (tmp != null && tmp.Length > 0)
            {
                foreach (string t in tmp)
                {
                    if (t.Count(x => x == '/') == 2)
                    {
                        res.Add(t.Substring(0, t.LastIndexOf("/") - 1));
                    }
                }
            }

            return res;

        }

        public List<string> DoOperation(string input)
        {
            return ParseResult(Classifier.classifyToString(input));
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Classifier = null;
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
